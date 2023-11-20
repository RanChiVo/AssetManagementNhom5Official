#!/bin/bash

SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
ROOT_PROJECT=$(realpath "$SCRIPTPATH/../..")

function refreshSwagger() {
    "$ROOT_PROJECT/angular/node_modules/.bin/nswag" run "$ROOT_PROJECT/angular/nswag/service.config.nswag"
}

function setupAngular() {
    npm run start-server
}

function main() {
    refreshSwagger
    setupAngular
}

main