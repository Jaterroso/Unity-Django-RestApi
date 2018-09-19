from django.db import models
import datetime
from django.urls import reverse #Used to generate URLs by reversing the URL patterns
from django.contrib.auth.models import User #Blog author or commenter

def user_directory_path(instance, filename):
    # file will be uploaded to MEDIA_ROOT/user_<id>/<filename>
    return '{0}/{date:%Y-%m-%d %H:%M:%S}_{1}'.format(instance.user.username,filename,date=datetime.datetime.now())

class File(models.Model):
	file = models.FileField(upload_to=user_directory_path,blank=False, null=False)
	user = models.ForeignKey(User, on_delete=models.SET_NULL, null=True)
	filename = models.CharField(max_length=200)
	timestamp = models.DateTimeField(auto_now_add=True)
  
	class Meta:
		ordering = ["-timestamp","-filename"]
	
	
	
	def __str__(self):
		"""
			String for representing the Model object.
		"""
		return self.filename