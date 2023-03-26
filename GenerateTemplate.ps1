#Requires -Modules EPS

param(
    [Parameter(Mandatory)]
    [string] $Title,

    [Parameter(Mandatory)]
    [string] $Signature,

    [string] $Examples,

    [string] $SutClassDefinition
)


$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
trap { throw $Error[0] }

if ($MyInvocation.InvocationName -ne '.') {
    throw 'This script should be only called via dot-sourcing'
}

function ReadMultiline($prefix) {
    $result = '';
    $exitStr = '@@@'
    Write-Host "$($prefix): Enter multiline string ending with '$exitStr'"
    while ($true) {
        $line = Read-Host "Enter the next line (Enter '$exitStr' to exit)"
        if ($line -eq $exitStr) {
            return $result
        }
        $result += "$line`r`n"
    }
}

$Title = $Title -replace '^(\d+)\.', {
    $_.Groups[1].Value.PadLeft(4, '0')
}

$taskDir = mkdir "f:\dev\leetcode\LeetCode\$Title" -force
$escapedTitle = '_' + ($Title -replace '['' \-]', '_')

if ($Signature -eq 'SQL') {
    Set-Content -Path "$taskDir\Tests.cs" -Value (
        Invoke-EpsTemplate -Template @'
using JetBrains.Annotations;

namespace LeetCode.<%= $escapedTitle %>;

[UsedImplicitly]
public class Tests : SqlTestsBase<Tests>
{
}
'@);

    $setupScript = ReadMultiline 'SetUp script'

    Set-Content -Path "$taskDir\SetUp.sql" -Value $setupScript

    Set-Content -Path "$taskDir\Solution1.sql" -Value '-- TODO url'

    $testCases = @((ReadMultiline 'Test cases') -split "`n")
    $expectedOutputs = @((ReadMultiline 'Expected outputs') -split "`n")

    $n = $testCases.Length

    for ($i = 0; $i -lt $n - 1; $i++) {
        $testCaseObj = $testCases[$i] | ConvertFrom-Json
        $testCaseObj | Add-Member -Type NoteProperty -Name 'output' -Value ($expectedOutputs[$i] | ConvertFrom-Json)

        Set-Content -Path "$taskDir\TestCase$($i + 1).json" -Value ($testCaseObj | ConvertTo-Json -Depth 3)
    }

    return;
}

if (-not $Examples) {
    $Examples = ReadMultiline 'Examples'
}

$isSut = $false

if ($Signature -eq 'SUT') {
    $isSut = $true
    if (-not $SutClassDefinition) {
        $SutClassDefinition = ReadMultiline 'SUT class definition'
    }

    $sutClassName = $SutClassDefinition | Select-String 'public class (.+) \{' | ForEach-Object {$_.Matches.Groups[1].Value }
    $sutInterfaceName = 'I' + $sutClassName

    $sutMethods = $SutClassDefinition | Select-String '(public .+?\(.*?\)) \{' -AllMatches | ForEach-Object { $_.Matches } | ForEach-Object {$_.Groups[1].Value }

    $constructor = $sutMethods | Where-Object { $_.Contains("public $sutClassName") }

    $sutMethods = $sutMethods | Where-Object { $_ -ne $constructor }

    $sutArguments = $constructor | Select-String '\((.*)\)' | ForEach-Object {$_.Matches.Groups[1].Value }

    $Signature = "public $sutInterfaceName Create($sutArguments)"
    $sutArgumentNamesStr = ($sutArguments -split ', ' | Where-Object { $_ } | ForEach-Object { ($_ -split ' ')[1] }) -join ', '

    Set-Content -Path "$taskDir\$sutInterfaceName.cs" -Value (
        Invoke-EpsTemplate -Template @'
using JetBrains.Annotations;

namespace LeetCode.<%= $escapedTitle %>;

[PublicAPI]
public interface <%= $sutInterfaceName %>
{
    <%- $sutMethods | Each { -%>
    <%= $_ %>;<%
    } -Join "`r`n" %>
}
'@)

Set-Content -Path "$taskDir\$($sutClassName)1.cs" -Value (
        Invoke-EpsTemplate -Template @'
namespace LeetCode.<%= $escapedTitle %>;

/// <summary>
/// 
/// </summary>
public class <%= $sutClassName %>1 : <%= $sutInterfaceName %>
{
    public <%= $sutClassName %>1(<%= $sutArguments %>)
    {
        throw new NotImplementedException();
    }

    <%- $sutMethods | Each { -%>
    <%= $_ %>
    {
        throw new NotImplementedException();
    }<%
    } -Join "`r`n`r`n" %>
}
'@)
}

$examplesArr = @()

$exampleLines = $Examples -split "`r`n"
$lineIndex = -1

foreach ($line in $exampleLines) {
    $lineIndex++
    if (-not $line) {
        continue
    }

    if (-not $isSut) {
        if ($line -match '^Input: ') {
            $parts = @()

            $isInQuotedString = $false
            foreach ($part in $line -split ', ') {
                $hasQuote = $part -match '"'
                $hasTwoQuotes = $part -match '".*"'
                if (-not $isInQuotedString) {
                    $parts += $part
                    $isInQuotedString = $hasQuote -and -not $hasTwoQuotes
                } else {
                    $parts[-1] += ", $part"
                    if ($hasQuote) {
                        $isInQuotedString = $false
                    }
                }
            }

            [string[]] $exampleArguments = $parts | % { 
                ($_ -split ' = ')[1]
            }
        }

        if ($line -match '^Output: ') {
            $exampleOutput = $line -replace '^Output: '
            $exampleArguments += $exampleOutput

            $examplesArr += [PSCustomObject]@{
                Arguments = $exampleArguments;
            }
        }
    } elseif ($line -eq 'Input') {
        $commandsStr = $exampleLines[$lineIndex + 1]
        $argumentsStr = $exampleLines[$lineIndex + 2]
    } elseif ($line -eq 'Output') {
        $outputStr = $exampleLines[$lineIndex + 1]
        $examplesArr += [PSCustomObject]@{
            Arguments = @($commandsStr, $argumentsStr, $outputStr);
        }
    }
}

Set-Content -Path "$taskDir\ISolution.cs" -Value (
    Invoke-EpsTemplate -Template @'
using JetBrains.Annotations;

namespace LeetCode.<%= $escapedTitle %>;

[PublicAPI]
public interface ISolution
{
    <%= $Signature %>;
}
'@
)

Set-Content -Path "$taskDir\Solution1.cs" -Value (
    Invoke-EpsTemplate -Template @'
using JetBrains.Annotations;

namespace LeetCode.<%= $escapedTitle %>;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    <%= $Signature %>
    {
        <%
        if ($isSut) {
        %>return new <%= $sutClassName %>1(<%= $sutArgumentNamesStr %>);<%
        } else {
        %>throw new NotImplementedException();<%
        } %>
    }
}
'@
)

function ToPascalCase([string] $str) {
    if (-not $str) {
        return $str
    }

    return [char]::ToUpper($str[0]) + $str.Substring(1)
}

if ($Signature -notmatch '^public (?<OutputType>\S+) (?<MethodName>\S+?)\s*\((?<Arguments>.+)?\)$') {
    throw 'Wrong signature'
}

if (-not $isSut) {
    $outputType = $Matches.OutputType
    $methodName = $Matches.MethodName
    $arguments = @($Matches.Arguments -split ', ') + "$($Matches.OutputType) output" | ForEach-Object {
        $parts = $_ -split ' '
        $originalType = $parts[0]

        $jsonName = $parts[1]
        $name = ToPascalCase($jsonName);
        $type = $originalType
        
        switch ($originalType) {
            'ListNode' { 
                $type = 'int[]'
                $argumentStr = "ListNode.Create(testCase.$name)"
            }
            'TreeNode' {
                $type = 'int?[]'
                $argumentStr = "TreeNode.Create(testCase.$name)"
            }
            default {
                $type = $originalType
                $argumentStr = "testCase.$name"
            }
        }

        [PSCustomObject]@{
            Type = $type;
            Name = $name;
            JsonName = $jsonName;
            ArgumentStr = $argumentStr;
        } 
    }
} else {
    $arguments = @(
        @{
            Type = 'string[]';
            JsonName = 'commands';
        },
        @{
            Type = 'object[][]';
            JsonName = 'parameters';
        },
        @{
            Type = 'object[]';
            JsonName = 'output';
        }
    )
}

function InitStringIfNeeded($type) {
    switch ($type) {
        'int' { return '' }
        'long' { return '' }
        'bool' { return '' }
        default {
            return ' = null!;'
        }
    }
}

$invokeSolutionCodeStr = Invoke-EpsTemplate -Template @'
solution.<%= $methodName %>(<%-
    $arguments | Where-Object { $_.Name -ne 'Output' } | Each {
        -%><%= $_.ArgumentStr -%>
    <%- } -Join ', '
-%>)
'@

if (-not $isSut) {
    $isCollectionOutput = $outputType -match '^IList|\[\]$'

    Set-Content -Path "$taskDir\Tests.cs" -Value (
        Invoke-EpsTemplate -Template @'
<% if (-not $isCollectionOutput) {
    -%>using NUnit.Framework;<%-
} %>
using JetBrains.Annotations;

namespace LeetCode.<%= $escapedTitle %>;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        <% if ($isCollectionOutput) {
            -%>AssertCollectionEqualWithDetails(<%= $invokeSolutionCodeStr %>, <%= $arguments[-1].ArgumentStr %>);<%-
        } else {
            -%>Assert.That(<%= $invokeSolutionCodeStr %>, Is.EqualTo(<%= $arguments[-1].ArgumentStr %>));<%-
        } %>
    }

    public class TestCase : TestCaseBase
    {
        <%- $arguments | Each { -%>
        public <%= $_.Type %> <%= $_.Name %> { get; [UsedImplicitly] init; }<%= InitStringIfNeeded $_.Type %><%
        } -Join "`r`n" %>
    }
}
'@)
} else {
    Set-Content -Path "$taskDir\Tests.cs" -Value (
        Invoke-EpsTemplate -Template @'
using JetBrains.Annotations;

namespace LeetCode.<%= $escapedTitle %>;

[UsedImplicitly]
public class Tests : SutTestsBase<ISolution, <%= $sutInterfaceName %>>
{
}
'@);
}

$counter = 1

foreach ($example in $examplesArr) {
    $counterStr = $counter.ToString('D' + $examplesArr.Length.ToString().Length)
    Set-Content -Path "$taskDir\TestCase$counterStr.json" -Value (
        Invoke-EpsTemplate -Template @'
{
  <%- $arguments | Each { -%>
  "<%= $_.JsonName %>": <%= $example.Arguments[$index] %><%-
  } -Join ",`r`n" %>
}
'@)

    $counter++
}

