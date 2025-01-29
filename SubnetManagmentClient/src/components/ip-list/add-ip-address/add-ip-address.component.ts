import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-ip-address',
  standalone: false,
  
  templateUrl: './add-ip-address.component.html',
  styleUrl: './add-ip-address.component.css'
})
export class AddIpAddressComponent {
  ipForm: FormGroup;
  isEdit: boolean = false;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<AddIpAddressComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.isEdit = !!data;
    this.ipForm = this.fb.group({
      ipAddressValue: [data.ipAddressValue || '', [Validators.required,
        Validators.pattern('^([0-9]{1,3}\\.){3}[0-9]{1,3}$'),
      ]],
    });
  }

  save(): void {
    if(this.ipForm.invalid){ return; }
    if (this.ipForm.valid) {
      const result = { ...this.data, ...this.ipForm.value };
      this.dialogRef.close(result);
    }
  }

  close(): void {
    this.dialogRef.close(this.ipForm.value);
  }
}
