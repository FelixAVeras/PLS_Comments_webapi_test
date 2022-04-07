
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Subject } from 'rxjs';
import { Comments } from '../models/comment';

import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  constructor(private http: HttpClient) { }

  public subjectData$ = new Subject<Comments>();


  private hubConnection: signalR.HubConnection | undefined;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7256/hub')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addTransferChartDataListener = (id: string) => {
    this.hubConnection!.on(id, (data) => {
      this.subjectData$.next(data);
      console.log(data);
    });
  }

  public SendComment(id: string, comment: Comments) {
    console.log(comment)
    return this.http.post(`https://localhost:7256/api/Comments/${id}`, comment, {
      headers: new HttpHeaders().set('Content-Type', 'application/json')
    });

  }
}
