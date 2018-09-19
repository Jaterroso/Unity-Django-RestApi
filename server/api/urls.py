from django.conf.urls import url
from .views import FileView
from django.urls import include, path
urlpatterns = [
  url(r'^files/$', FileView.as_view(), name='file-owner'),
  url(r'^rest-auth/', include('rest_auth.urls')),
  url(r'^rest-auth/registration/', include('rest_auth.registration.urls'))
]