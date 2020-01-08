docker build -t suncoast-overflow-image .

docker tag suncoast-overflow-image registry.heroku.com/suncoast-overflow/web

docker push registry.heroku.com/suncoast-overflow/web

heroku container:release web -a suncoast-overflow