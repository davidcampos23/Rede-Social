import { CommonModule, NgOptimizedImage } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule, NgOptimizedImage],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent{
  
  constructor(private httpClient : HttpClient, private router : Router){ }
  
  user: any = {
    userName : '',
    email : '',
    password : '',
    image : ''
  }

  userPasswordConfirm : any = {
    passwordInitial : '',
    passwordConfirm : ''
  }

  async onSubmit(){
    
    if(this.userPasswordConfirm.passwordInitial != this.userPasswordConfirm.passwordConfirm){
      return alert("Senhas Diferentes!");
    }

    this.user.password = this.userPasswordConfirm.passwordInitial;

    if(this.user.userName == ''){
      return alert("User Name Null");
    }

    if(this.user.email == ''){
      return alert("Email Null");
    }

    if(this.user.password == ''){
      return alert("Password Null");
    }
     
    try{
      const base64Image = await this.imageDefault()
      this.user.image = base64Image;

    }catch(error){console.log('Erro ao carregar Imagem:', error)};
    
    this.createUserCommand()
  }

  createUserCommand()
  {
    this.httpClient.post('http://localhost:5041/api/register/user/create',this.user).subscribe((response : any) =>{
      if(response){
        this.router.navigate(['/home']);
      }
    });
  }


  async imageDefault(){
    const filePath = '/assets/imagemPerfil.jpg';

    try {
      const response = await fetch(filePath);
      const blob = await response.blob();

      return new Promise<string>((resolve, reject) =>{

        const reader = new FileReader();
        reader.onload = () => {
        let base64String: string = reader.result as string;
        const commaIndex = base64String.indexOf(',');

        if (commaIndex !== -1) {
          base64String = base64String.substring(commaIndex + 1);
        }

        resolve(base64String);
      };
      
      reader.onerror= (error) =>{
        reject(error);
      };
      
      reader.readAsDataURL(blob);
    });
    } catch (error) {
      console.error('Erro ao carregar Arquivo:', error);
      throw error;
    }
  }



}
