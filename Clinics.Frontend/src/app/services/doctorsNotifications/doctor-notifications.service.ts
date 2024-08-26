import { Injectable } from '@angular/core';
import { HubConnectionBuilder } from '@microsoft/signalr';
import * as config from '../../../../config'

@Injectable({
  providedIn: 'root'
})
export class DoctorNotificationsService {

  constructor() { }

  private readonly NOTIFICATIONS_ENDPOINT: string = `${config.apiUrl}/Notifications/Doctors`;
  hubConnection: signalR.HubConnection;
  
  startConnection(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.NOTIFICATIONS_ENDPOINT)
      .build();

    this.hubConnection
      .start()
      .then(() => {
        // console.log('Connected to signalR!')
      })
      .catch(
        // err => console.error('Error while starting connection: ' + err)
    )
  }

}
