import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from './../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WordToNumberService {

  constructor(private http: HttpClient) { }

  getConvert(input: string) {
    return this.http.get<ConversionResponse>(`${environment.apiUrl}api/ConvertToWord/${input}`);
  }
}
export class ConversionResponse {
  result!: string
}
