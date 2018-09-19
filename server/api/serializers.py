from rest_framework import serializers
from .models import File
from rest_framework.fields import CurrentUserDefault
class FileSerializer(serializers.ModelSerializer):
	
	
	class Meta():
		model = File
		fields = ('file', 'filename','user')
		
	def to_representation(self, obj):
		return {
            'file': obj.file.url,
            'filename': obj.filename,
			'timestamp': obj.timestamp
        }
	
	
	