from rest_framework.views import APIView
from rest_framework.parsers import MultiPartParser, FormParser
from rest_framework.response import Response
from rest_framework import status
from .serializers import FileSerializer
from rest_framework.decorators import api_view, permission_classes
from rest_framework.permissions import IsAuthenticated
from rest_framework.response import Response
from .models import File
from rest_framework import serializers
from rest_framework import generics
class FileView(generics.ListCreateAPIView):
	permission_classes = (IsAuthenticated,)
	parser_classes = (MultiPartParser, FormParser)
	queryset = File.objects.all()
	serializer_class = FileSerializer
		
	
	def perform_create(self, serializer):
		print (self.request.user)
		serializer.save(user=self.request.user)

		
  