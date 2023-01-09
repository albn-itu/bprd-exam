#!/bin/sh
binDir=/data/bin

$binDir/compileParser.sh C
$binDir/compileLexer.sh C

$binDir/run.sh Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs
