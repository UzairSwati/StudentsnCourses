import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'get-students-list-app';
  data;
constructor(private httpClient: HttpClient) {}
  OnClick() {
    this.httpClient.get('https://jsonplaceholder.typicode.com/posts').subscribe((res) => {
      //this.httpClient.get('https://localhost:5001/students/all').subscribe((res)=> {
    this.data = res;
    })
  }

  OnEraseButtonClick() {
    this.data = null;
  }
}
