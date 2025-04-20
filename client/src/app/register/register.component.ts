import { JsonPipe } from '@angular/common';
import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  imports: [FormsModule , JsonPipe],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  usersFromHomeComponent = input.required<any>();
  //@Output() cancelRegister = new EventEmitter();
  cancelRegister = output<boolean>();
  model: any = {}
  
  register() {
    this.accountService.register(this.model).subscribe({
      next: res => {
        console.log(res);
        this.cancel();
      },
      error: error => console.log(error)
    });
    
  }

  cancel() {
    console.log('cancelled')
    this.cancelRegister.emit(false);
  }
}
