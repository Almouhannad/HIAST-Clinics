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
import { ReceptionistUserComponent } from './components/admin/receptionist-user/receptionist-user.component';
import { ReceptionistUsersComponent } from './components/admin/receptionist-users/receptionist-users.component';
import { ReceptionistUsersService } from './services/admin/receptionist-users.service';
import { ReceptionistDashboardComponent } from './components/receptionist/receptionist-dashboard/receptionist-dashboard.component';
import { WaitingListComponent } from './components/receptionist/waiting-list/waiting-list.component';
import { WaitingListItemComponent } from './components/receptionist/waiting-list-item/waiting-list-item.component';
import { DoctorsComponent } from './components/receptionist/doctors/doctors.component';
import { DoctorItemComponent } from './components/receptionist/doctor-item/doctor-item.component';
import { CreateWitingListItemAccordionComponent } from './components/receptionist/create-witing-list-item-accordion/create-witing-list-item-accordion.component';
import { CreateWitingListItemForEmployeeComponent } from './components/receptionist/create-witing-list-item-for-employee/create-witing-list-item-for-employee.component';
import { CreateWitingListItemForFamilyMemberComponent } from './components/receptionist/create-witing-list-item-for-family-member/create-witing-list-item-for-family-member.component';
import { CreateEmployeeFormComponent } from './components/receptionist/create-employee-form/create-employee-form.component';
import { EmployeeSerialNumberPopUpComponent } from './components/receptionist/employee-serial-number-pop-up/employee-serial-number-pop-up.component';
import { EmployeeComponent } from './components/receptionist/employee/employee.component';
import { WaitingListService } from './services/waitingList/waiting-list.service';
import { EmployeesDataService } from './services/employees/employees-data.service';
import { ScrollToTopDirective } from './directives/scroll-to-top.directive';
import { DoctorDashboardComponent } from './components/doctor/doctor-dashboard/doctor-dashboard.component';
import { DoctorNotificationsService } from './services/doctorsNotifications/doctor-notifications.service';
import { DoctorStatusComponent } from './components/doctor/doctor-dashboard/doctor-status/doctor-status.component';


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
    ReceptionistUsersService,
    WaitingListService,
    EmployeesDataService,
    DoctorNotificationsService,
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
    ReceptionistUserComponent,
    ReceptionistUsersComponent,
    ReceptionistDashboardComponent,
    WaitingListComponent,
    WaitingListItemComponent,
    DoctorsComponent,
    DoctorItemComponent,
    CreateWitingListItemAccordionComponent,
    CreateWitingListItemForEmployeeComponent,
    CreateWitingListItemForFamilyMemberComponent,
    CreateEmployeeFormComponent,
    EmployeeSerialNumberPopUpComponent,
    EmployeeComponent,
    ScrollToTopDirective,
    DoctorDashboardComponent,
    DoctorStatusComponent,
  ],
  
  // identifies the root component that Angular should
  // bootstrap when it starts the application
  bootstrap: [AppComponent]
})
export class AppModule { }
