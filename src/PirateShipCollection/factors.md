#### I. Codebase
The codebase is tracked via Github, the repository is actually public so you can look at it if you want.
https://github.com/derlistigelurch/PirateShipCollection

#### III. Config
The port, db address, db username, db password, and all the other configuration settings are stored in the docker-compose file.
These configurations are later used from the service.
For deployment the local config can also be changed.

#### IV. Backing services
The database is a completely detached service, with its own port and address.

#### VI. Processes
The service is stateless and the data is stored in a MSSql database.

#### VII. Port binding
All outgoing ports can be configured in the docker-compose file.

#### X. Dev/prod parity
The deployment of the service into production works the same as in development.
Simply start the webserver in your IDE to deploy the service in development mode or use the docker-compose file to deploy to production.
Also the db servers are the same.

#### XI. Logs
Logs are directly written to stdout and can therefore be redirected to a file or another service.

#### XII. Admin processes
There are two dev/admin actions which can be performed via the rest interface
1. Delete and re-create database
2. Fill database with test data
