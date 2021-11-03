#!/bin/bash

cd src/PirateShipCollection || exit
docker-compose up -d
xdg-open "" http://localhost:5000/swagger/index.html