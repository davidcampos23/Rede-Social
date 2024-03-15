import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit{
  data : any [] = [];

  constructor(private httpClient : HttpClient){}

  ngOnInit(): void {
      this.fetchData();
  }

  fetchData() {
    this.httpClient.get('http://localhost:5041/posts/obter').subscribe((data: any) =>{
    this.data = data;
    });
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