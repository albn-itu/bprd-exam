#!/bin/sh
binDir=/data/bin

$binDir/compileParser.sh Fun
$binDir/compileLexer.sh Fun

$binDir/run.sh Absyn.fs FunPar.fs FunLex.fs Parse.fs ParseAndRun.fs ParseAndRunHigher.fs
