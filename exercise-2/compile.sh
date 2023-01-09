#!/bin/sh
binDir=/data/bin

$binDir/compileParser.sh C
$binDir/compileLexer.sh C

fsharpc --standalone -r $binDir/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ListCC.fs -o listcc.exe
