import { Component } from '@angular/core';

@Component({
  selector: 'app-file-upload',
  standalone: false,
  
  templateUrl: './file-upload.component.html',
  styleUrl: './file-upload.component.css'
})
export class FileUploadComponent {
  selectedFile: File | null = null;

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  uploadFile() {
    if (this.selectedFile) {
      console.log('Uploading:', this.selectedFile.name);
      // Perform file upload logic
    }
  }
}
