import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/shared/root/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { LayoutComponent } from './components/shared/template/layout/layout.component';
import { HeaderComponent } from './components/shared/template/header/header.component';
import { FooterComponent } from './components/shared/template/footer/footer.component';
import { HomeComponent } from './components/shared/home/home.component';
import { LoginFormComponent } from './components/authentication/login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AuthenticationService } from './services/authentication/authentication.service';
import { AuthenticationInterceptor } from './services/authentication/interceptor/authentication.interceptor';
import { ForbiddenComponent } from './components/shared/errors/forbidden/forbidden.component';
import { NotFoundComponent } from './components/shared/errors/not-found/not-found.component';
import { TestSignalRComponent } from './components/notifications/test-signal-r/test-signal-r.component';
import { SignalRService } from './services/notifications/signal-r.service';
import { DoctorUsersComponent } from './components/admin/doctor-users/doctor-users.component';
import { DoctorUserComponent } from './components/admin/doctor-user/doctor-user.component';
import { DoctorUsersService } from './services/admin/doctor-users.service';
import { CreateDoctorUserFormComponent } from './components/admin/create-doctor-user-form/create-doctor-user-form.component';
import { AdminDashboardComponent } from './components/admin/admin-dashboard/admin-dashboard.component';
import { UpdateDoctorUserComponent } from './components/admin/update-doctor-user/update-doctor-user.component';
import { UpdateDoctorPersonalDataFormComponent } from './components/admin/update-doctor-personal-data-form/update-doctor-personal-data-form.component';
import { UpdateDoctorUserDataFormComponent } from './components/admin/update-doctor-user-data-form/update-doctor-user-data-form.component';


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
    CreateDoctorUserFormComponent,
    AdminDashboardComponent,
    UpdateDoctorUserComponent,
    UpdateDoctorPersonalDataFormComponent,
    UpdateDoctorUserDataFormComponent,
  ],
  
  // identifies the root component that Angular should
  // bootstrap when it starts the application
  bootstrap: [AppComponent]
})
export class AppModule { }
