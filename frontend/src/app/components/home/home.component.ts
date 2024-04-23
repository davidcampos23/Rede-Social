import { CommonModule, NgOptimizedImage } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule, NgOptimizedImage,],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit{
  
  constructor(private httpClient : HttpClient, private route : ActivatedRoute){}

  ngOnInit(): void {
    this.userIdLogin = this.route.snapshot.paramMap.get('userId');
    this.loadingPosts();
    this.data.reverse();

    this.user.userId = this.userIdLogin;
  }
  
  data : any [] = [];
  userIdLogin : any = '';

  user :any = {
    userId: '',
    menssage: ''
  }


  createPost(){
    console.log(this.user);
    this.httpClient.post('http://localhost:5041/api/feed/post', this.user).subscribe((response : any) =>{
    response = this.user;
    location.reload();
    });
  }

  loadingPosts() {
    this.httpClient.get('http://localhost:5041/api/feed/get').subscribe((data: any) =>{
    this.data = data;
    });
  }

  //Load Image
  decodeString(base64String:string):string{
    return 'data:image/jpeg;base64,' + base64String;
  }

  //Change Image
  OnFileSelected(event : any){
    const file : File = event.target.files[0];
    const reader = new FileReader();

    reader.onload = () =>{
      let base64String:string = reader.result as string;
      const commamIndex = base64String.indexOf(',');

      if(commamIndex !== -1)
      {
        base64String = base64String.substring(commamIndex+1);
      }

      this.user.tokenImage = base64String;
    };

    reader.readAsDataURL(file);
  }


  formatDate(dateString : any) {
    const date = new Date(dateString);
            const day = date.getDate();
            const month = date.getMonth() + 1; // Mês é baseado em zero, então adicionamos 1
            const year = date.getFullYear();
            const hour = date.getHours();
            const minute = date.getMinutes();

            // Certifique-se de que o dia, mês, hora e minuto tenham dois dígitos
            const formattedDay = day < 10 ? '0' + day : day;
            const formattedMonth = month < 10 ? '0' + month : month;
            const formattedHour = hour < 10 ? '0' + hour : hour;
            const formattedMinute = minute < 10 ? '0' + minute : minute;

            return `${formattedDay}/${formattedMonth}/${year} ${formattedHour}:${formattedMinute}`;
}
}