import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../notifications/signal-r.service';

@Component({
  selector: 'app-test-signal-r',
  templateUrl: './test-signal-r.component.html',
  styleUrls: ['./test-signal-r.component.css']
})
export class TestSignalRComponent implements OnInit {

  notification: string = '';

  constructor(private signalR: SignalRService){}

  ngOnInit(): void {
    this.signalR.startConnection();
    this.signalR.hubConnection.on('ReceiveNotification', (message) => {
      this.notification = message;
    })
  }

  onClick(): void {
    this.signalR.endConnection();
  }

}