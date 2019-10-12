dotnet publish -c Release 

cp dockerfile ./bin/release/netcoreapp2.2/publish

docker build -t game-starter-app-image ./bin/release/netcoreapp2.2/publish

docker tag game-starter-app-image registry.heroku.com/game-starter-app/web

docker push registry.heroku.com/game-starter-app/web

heroku container:release web -a game-starter-app

# sudo chmod 755 deploy.sh
# ./deploy.sh