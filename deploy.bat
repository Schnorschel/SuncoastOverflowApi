docker build -t suncoast-overflow-oehl-image .

docker tag suncoast-overflow-oehl-image registry.heroku.com/suncoast-overflow-oehl/web

docker push registry.heroku.com/suncoast-overflow-oehl/web

heroku container:release web -a suncoast-overflow-oehl