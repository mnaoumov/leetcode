# More than a pipe's buffer on each stream, so reading one stream to its end first would deadlock.
seq 1 100000
seq 1 100000 >&2
