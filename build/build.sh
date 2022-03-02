#!/bin/bash
set -euxo pipefail

# Install docker-compose
pip install --upgrade pip
pip install docker-compose

# Build
docker-compose build
