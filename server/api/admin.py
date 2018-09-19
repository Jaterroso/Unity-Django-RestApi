from django.contrib import admin
from .models import File

class FileAdmin(admin.ModelAdmin):
	list_display = ('filename','user', 'timestamp')
	list_filter = ('user', 'timestamp')
# Register your models here.
admin.site.register(File,FileAdmin)
