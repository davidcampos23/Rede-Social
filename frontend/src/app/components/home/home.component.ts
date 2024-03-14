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
}
