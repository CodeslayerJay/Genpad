import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  model = new CardTest("","");
  _http: HttpClient;
  _url: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this._http = http;
    this._url = baseUrl + 'api/Cards';
  }

  save() {
    this._http.post(this._url, this.model).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
}


export class CardTest {
  constructor(
    public title: string,
    public note: string
    ) {}
}

