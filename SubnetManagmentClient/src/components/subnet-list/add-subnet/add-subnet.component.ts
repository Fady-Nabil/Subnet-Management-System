import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SubnetService } from '../../../services/subnet.service';
import { SubnetDto } from '../../../models/subnet-dto';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-subnet',
  standalone: false,
  
  templateUrl: './add-subnet.component.html',
  styleUrl: './add-subnet.component.css'
})
export class AddSubnetComponent {
  subnetForm: FormGroup;
  isEdit: boolean = false;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<AddSubnetComponent>,
    public subnetService: SubnetService,
    private snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: any 
  ) {
    this.isEdit = !!data; 
    this.subnetForm = this.fb.group({
      subnetName: [data?.subnetName || '', Validators.required],
      subnetAddress: [data?.subnetAddress || '', Validators.required,
        Validators.pattern(
          '^([0-9]{1,3}\\.){3}[0-9]{1,3}\\/(3[0-2]|[12][0-9]|[0-9])$'
        ),
      ]
    });
  }

  
  
  showAlert(message: string, action: string = 'Close') {
    this.snackBar.open(message, action, {
      duration: 3000, 
      horizontalPosition: 'right',
      verticalPosition: 'top',
    });
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

  save(): void {
    if (this.subnetForm.valid) {
      this.dialogRef.close(this.subnetForm.value);
    }
  }
}
