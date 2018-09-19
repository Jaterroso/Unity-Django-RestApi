# Unity-Django-RestApi

1 - Setup 
=============

Setup heroku toolbelt

Setup s3 amazon and add AWS_ACCESS_KEY_ID ,AWS_SECRET_ACCESS_KEY, AWS_STORAGE_BUCKET_NAME to server/helloworld/settings.py

2 - Push server to heroku:
=============
.. code:: bash

    cd server

    heroku create

    git add .

    git commit -m "initial commit"

    git push heroku master

    heroku run python manage.py makemigratiosn

    heroku run python manage.py migrate

    heroku open

3 - Client
=============
  Change url in client/assets/scripts/contants.cs
