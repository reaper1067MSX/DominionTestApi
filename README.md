# DominionTestApi
Instruction set for deployment

# Documentation of api
https://documenter.getpostman.com/view/8824037/UUy1eSHD

# Collection import
https://www.getpostman.com/collections/861e3b850e0b73fb3b1d

# Steps

1. Restore DB provided, that inside project Dominion.Test.Infrastructure/Db
2. Change the connection string to ajust a your configurations
3. Inside the project Dominion.Test.Api modify the file appsettings.json
4. Change the labels DefaultConnection for your string connection in your DB, THIS PROJECT ONLY SUPPORT SQL
5. Change the label External for your name server of DB
6. Select the profile production
7. Start the app
