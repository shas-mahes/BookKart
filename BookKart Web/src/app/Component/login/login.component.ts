import { Component, OnInit } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogModule,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import {
  FormControl,
  Validators,
  FormsModule,
  ReactiveFormsModule,
  FormGroup,
} from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    MatDialogModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  isPassVisible: boolean;

  constructor(private userService: UserService, public dialog: MatDialog) {
    this.isPassVisible = false;
  }

  ngOnInit(): void {
    this.loginForm = this.createLoginForm();
  }

  createLoginForm(): FormGroup {
    const form = new FormGroup({
      EmailId: new FormControl('', [Validators.required, Validators.email]),
      Password: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
    });
    return form;
  }

  showPassword() {
    this.isPassVisible = !this.isPassVisible;
  }

  validateUser() {
    const emailId = this.loginForm.get('EmailId')?.value;
    const password = this.loginForm.get('Password')?.value;
    this.userService
      .authenticateUser(emailId, password)
      .subscribe((response) => {
        if (response.ResponseCode == 'Success') {
          console.log('User Authenticated');
          this.dialog.closeAll();
        }
      });
  }
}
