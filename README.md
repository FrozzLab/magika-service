## Desktop application used for interaction with locally-hosted SQLite database, based around the fictional company "Magika".

### ! The path to the database location is hardcoded, so it would have to be switched to function properly.

The application utilizes the MVVM pattern to provide interaction between a "benefactor" and a "mage", whose roles are as follows:
A mage proposes a contract to a benefactor for certain services, and proposes an initial price. The benefactor may offer an alternative price, accept the offer, or decline it. The mage, similarly, may respond to new price propositions from a benefactor, and accept or reject the terms of the agreement. The desktop application uses WPF for the visual presentation, and follows the MVVM pattern in the backend. The database service used for the application is SQLite, and the database is seeded by the application for testing purposes.
