import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth',
  standalone: false,
  
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent {
  loginForm: FormGroup;
  registerForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });

    this.registerForm = this.fb.group({
      email: [''],
      password: [''],
      confirmPassword: ['']
    });
  }

  onLogin() {
    if (this.loginForm.valid) {
      // Get form values
      const formValues = this.loginForm.value; // Returns { email: 'value', password: 'value' }
      console.log('Form Values:', formValues);

      const email = this.loginForm.get('email')?.value; // Get individual email value
      const password = this.loginForm.get('password')?.value; // Get individual password value
      console.log('Email:', email);
      console.log('Password:', password);
    } else {
      console.error('Form is invalid');
    }

  }

  onRegister() {
    console.log(this.registerForm.value);
  }
}
