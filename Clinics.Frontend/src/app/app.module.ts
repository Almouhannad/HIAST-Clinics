import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './usecases/shared/components/root/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { LayoutComponent } from './usecases/shared/components/template/layout/layout.component';
import { HeaderComponent } from './usecases/shared/components/template/header/header.component';
import { FooterComponent } from './usecases/shared/components/template/footer/footer.component';
import { HomeComponent } from './usecases/shared/components/home/home.component';
import { LoginFormComponent } from './authentication/components/login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from './authentication/services/authentication.service';
import { AuthenticationInterceptor } from './authentication/services/interceptor/authentication.interceptor';
import { ForbiddenComponent } from './usecases/shared/components/errors/forbidden/forbidden.component';
import { NotFoundComponent } from './usecases/shared/components/errors/not-found/not-found.component';
import { TestSignalRComponent } from './notifications/components/test-signal-r/test-signal-r.component';
import { SignalRService } from './notifications/services/signal-r.service';
import { DoctorUsersComponent } from './usecases/admin/list-doctor-users/components/doctor-users/doctor-users.component';
import { DoctorUserComponent } from './usecases/admin/list-doctor-users/components/doctor-user/doctor-user.component';
import { DoctorUsersService } from './usecases/admin/services/doctor-users.service';


@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    NgbModule,
    ToastrModule.forRoot({
      timeOut: 2500,
    }),
    FormsModule,
    HttpClientModule,
  ],

  // creators of services that this module contributes to the
  // global collection of services; they become accessible in
  // all parts of the app
  providers: [
    AuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true},
    SignalRService,
    DoctorUsersService,
  ],

  // components and directives that belong to this module
  // the subset of declarations that should be visible and usable in
  // the component templates of other modules
  declarations: [
    AppComponent,
    LayoutComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    LoginFormComponent,
    ForbiddenComponent,
    NotFoundComponent,
    TestSignalRComponent,
    DoctorUserComponent,
    DoctorUsersComponent,
  ],
  
  // identifies the root component that Angular should
  // bootstrap when it starts the application
  bootstrap: [AppComponent]
})
export class AppModule { }
