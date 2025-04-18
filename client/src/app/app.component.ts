
import { JsonPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [JsonPipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  private readonly http: HttpClient = inject(HttpClient);
  title = 'DatingApp';
  users: any;
  

  ngOnInit(): void {
    this.http.get<any[]>('https://localhost:5001/api/Users').subscribe({
      next: (res: any) => { this.users = res },
      error: (error: any) => { console.log(error) },
      complete: () => console.log('Request has completed')

    })
  }
}
