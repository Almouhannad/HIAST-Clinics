import { Injectable } from '@angular/core';
import { HubConnectionBuilder } from '@microsoft/signalr';
import * as config from '../../../../config'

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  constructor() { }

  private readonly NOTIFICATIONS_ENDPOINT: string = `${config.apiUrl}/Notifications`
  hubConnection: signalR.HubConnection;

  startConnection(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.NOTIFICATIONS_ENDPOINT)
      .build();

    this.hubConnection
      .start()
      .then(() => {
        console.log('Connected to signalR!')
      })
      .catch(err => console.error('Error while starting connection: ' + err))
  }

  endConnection(): void {
    if (this.hubConnection) {
      this.hubConnection
        .stop()
        .then(() => {
          console.log('disonnected from signalR!');
        })
        .catch(err => console.error('Error while stopping connection: ' + err));
    } else {
      console.log('No active connection to stop.');
    }
  
  }
}