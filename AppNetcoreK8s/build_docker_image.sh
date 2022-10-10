#!/bin/bash
set -e

# Build backend & ApiGateway binary
docker build -f AppNetcoreK8s/Dockerfile -t kenriortega/apicore:v0.0.1 .
