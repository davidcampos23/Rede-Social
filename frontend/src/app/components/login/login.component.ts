import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [HttpClientModule, FormsModule, CommonModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor(private httpClient : HttpClient, private router : Router){}

  userLogin : any = {
    email: '',
    password: ''
  }

  loginSubmit(){
    this.httpClient.post('http://localhost:5041/api/register/user/login', this.userLogin).subscribe((response : any)=>{
      if(response){
        this.redirectHome();
      }

    });
  }

  redirectHome(){
    this.router.navigate(['/home'])
  }
}
