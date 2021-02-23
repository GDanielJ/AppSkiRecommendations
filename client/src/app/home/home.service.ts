import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Skier } from '../_models/skier';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRecommendation(age: number, height: number, discipline: string): Observable<Skier> {
    let params = "age=" + age + "&height=" + height + "&discipline=" + discipline;

    const opts = { params: new HttpParams({ fromString: params }) };

    return this.http.get<Skier>(this.baseUrl + 'recommendation', opts);
  }
}
