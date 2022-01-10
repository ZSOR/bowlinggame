# bowlinggame

Usage:

- The easiest way to launch the API is by using the Dockerfil withing the BowlingGame folder. 
- The API endpoints can be found here: https://localhost:{port}/swagger/index.html where port is whatever port you link your docker container to. 
- It can also be run from VS 2022 by opening BowlingGame.sln and running with Docker within VS



# Notes #

- As it is currently configured the project uses an in memory database, I changed it to this to make testing easier. There is infrastructure there to run the code agains a MySql instance however, and this is how I would see it being deployed for production. 
- I created a "ScoreCard" object which currently has a 1-1 mapping to a "Player", this isn't strictly necessary but it does mean the the concerns are seperate and means it would be easy in future to create an API where 1 player can participate in many games. 
