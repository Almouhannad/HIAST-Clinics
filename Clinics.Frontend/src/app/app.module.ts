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
import { LoginFormComponent } from './components/usecases/shared-usecases/login/login-form/login-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from './services/authentication/authentication.service';
import { AuthenticationInterceptor } from './services/authentication/interceptor/authentication.interceptor';
import { ForbiddenComponent } from './components/shared/errors/forbidden/forbidden.component';
import { NotFoundComponent } from './components/shared/errors/not-found/not-found.component';
import { DoctorUsersComponent } from './components/usecases/admin-usecases/list-doctor-users/doctor-users/doctor-users.component';
import { DoctorUserComponent } from './components/usecases/admin-usecases/list-doctor-users/doctor-user/doctor-user.component';
import { DoctorUsersService } from './services/doctor-users/doctor-users.service';
import { CreateDoctorUserFormComponent } from './components/usecases/admin-usecases/create-doctor-user/create-doctor-user-form/create-doctor-user-form.component';
import { AdminDashboardComponent } from './components/usecases/admin-usecases/shared/admin-dashboard/admin-dashboard.component';
import { UpdateDoctorUserComponent } from './components/usecases/admin-usecases/update-doctor-user/shared/update-doctor-user/update-doctor-user.component';
import { UpdateDoctorPersonalDataFormComponent } from './components/usecases/admin-usecases/update-doctor-user/update-doctor-user-personal-data/update-doctor-personal-data-form/update-doctor-personal-data-form.component';
import { UpdateDoctorUserDataFormComponent } from './components/usecases/admin-usecases/update-doctor-user/update-doctor-user-account-data/update-doctor-user-data-form/update-doctor-user-data-form.component';
import { ReceptionistUserComponent } from './components/usecases/admin-usecases/list-receptionist-users/receptionist-user/receptionist-user.component';
import { ReceptionistUsersComponent } from './components/usecases/admin-usecases/list-receptionist-users/receptionist-users/receptionist-users.component';
import { ReceptionistUsersService } from './services/receptionist-users/receptionist-users.service';
import { ReceptionistDashboardComponent } from './components/usecases/receptionist-usecases/shared/receptionist-dashboard/receptionist-dashboard.component';
import { WaitingListComponent } from './components/usecases/receptionist-usecases/list-waiting-list-items/waiting-list/waiting-list.component';
import { WaitingListItemComponent } from './components/usecases/receptionist-usecases/list-waiting-list-items/waiting-list-item/waiting-list-item.component';
import { DoctorsComponent } from './components/usecases/receptionist-usecases/list-doctors/doctors/doctors.component';
import { DoctorItemComponent } from './components/usecases/receptionist-usecases/list-doctors/doctor-item/doctor-item.component';
import { CreateWitingListItemAccordionComponent } from './components/usecases/receptionist-usecases/create-waiting-list-item/create-witing-list-item-accordion/create-witing-list-item-accordion.component';
import { CreateWitingListItemForEmployeeComponent } from './components/usecases/receptionist-usecases/create-waiting-list-item/create-witing-list-item-for-employee/create-witing-list-item-for-employee.component';
import { CreateWitingListItemForFamilyMemberComponent } from './components/usecases/receptionist-usecases/create-waiting-list-item/create-witing-list-item-for-family-member/create-witing-list-item-for-family-member.component';
import { CreateEmployeeFormComponent } from './components/usecases/receptionist-usecases/create-employee/create-employee-form/create-employee-form.component';
import { EmployeeSerialNumberPopUpComponent } from './components/usecases/receptionist-usecases/shared/employee-serial-number-pop-up/employee-serial-number-pop-up.component';
import { EmployeeComponent } from './components/usecases/receptionist-usecases/show-employee/employee/employee.component';
import { WaitingListService } from './services/waitingList/waiting-list.service';
import { EmployeesDataService } from './services/employees/employees-data.service';
import { ScrollToTopDirective } from './directives/scroll-to-top.directive';
import { DoctorDashboardComponent } from './components/usecases/doctor-usecases/shared/doctor-dashboard/doctor-dashboard.component';
import { DoctorNotificationsService } from './services/notifications/doctor-notifications/doctor-notifications.service';
import { DoctorStatusComponent } from './components/usecases/doctor-usecases/show-status/doctor-status/doctor-status.component';
import { AskForSerialNumberComponent } from './components/usecases/doctor-usecases/shared/ask-for-serial-number/ask-for-serial-number.component';
import { HistoryComponent } from './components/usecases/doctor-usecases/list-visits-history/history/history.component';
import { VisitComponent } from './components/usecases/doctor-usecases/create-visit/visit/visit.component';
import { CreateVisitComponent } from './components/usecases/doctor-usecases/create-visit/create-visit/create-visit.component';
import { MedicinesComponent } from './components/usecases/doctor-usecases/list-visits-history/medicines/medicines.component';
import { AccordionDirective } from './directives/accordion.directive';
import { PatientIsComingNotificationComponent } from './components/notifications/doctor-notifications/patient-is-coming-notification/patient-is-coming-notification.component';
import { VisitsService } from './services/visits/visits.service';
import { ArabicDatePipe } from './pipes/arabic-date.pipe';
import { MedicinesService } from './services/medicines/medicines.service';
import { SearchForMedicineComponent } from './components/usecases/doctor-usecases/create-visit/search-for-medicine/search-for-medicine.component';
import { DoctorPhoneComponent } from './components/usecases/doctor-usecases/list-doctor-phones/doctor-phone/doctor-phone.component';
import { DoctorPhonesComponent } from './components/usecases/doctor-usecases/list-doctor-phones/doctor-phones/doctor-phones.component';
import { CreateDoctorPhoneComponent } from './components/usecases/doctor-usecases/create-doctor-phone/create-doctor-phone/create-doctor-phone.component';


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
    FormsModule,
    ReactiveFormsModule
  ],

  // creators of services that this module contributes to the
  // global collection of services; they become accessible in
  // all parts of the app
  providers: [
    AuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true},
    DoctorUsersService,
    ReceptionistUsersService,
    WaitingListService,
    EmployeesDataService,
    DoctorNotificationsService,
    VisitsService,
    MedicinesService,
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
    AskForSerialNumberComponent,
    HistoryComponent,
    VisitComponent,
    CreateVisitComponent,
    MedicinesComponent,
    AccordionDirective,
    PatientIsComingNotificationComponent,
    ArabicDatePipe,
    SearchForMedicineComponent,
    DoctorPhoneComponent,
    DoctorPhonesComponent,
    CreateDoctorPhoneComponent,
  ],
  
  // identifies the root component that Angular should
  // bootstrap when it starts the application
  bootstrap: [AppComponent]
})
export class AppModule { }
