import { NgModule } from '@angular/core';
import { HomeComponent } from './components/shared/home/home.component';
import { ForbiddenComponent } from './components/shared/errors/forbidden/forbidden.component';
import { NotFoundComponent } from './components/shared/errors/not-found/not-found.component';
import { DoctorUsersComponent } from './components/usecases/admin-usecases/list-doctor-users/doctor-users/doctor-users.component';
import { CreateDoctorUserFormComponent } from './components/usecases/admin-usecases/create-doctor-user/create-doctor-user-form/create-doctor-user-form.component';
import { AdminDashboardComponent } from './components/usecases/admin-usecases/shared/admin-dashboard/admin-dashboard.component';
import { UpdateDoctorUserComponent } from './components/usecases/admin-usecases/update-doctor-user/shared/update-doctor-user/update-doctor-user.component';
import { ReceptionistUsersComponent } from './components/usecases/admin-usecases/list-receptionist-users/receptionist-users/receptionist-users.component';
import { ReceptionistDashboardComponent } from './components/usecases/receptionist-usecases/shared/receptionist-dashboard/receptionist-dashboard.component';
import { WaitingListComponent } from './components/usecases/receptionist-usecases/list-waiting-list-items/waiting-list/waiting-list.component';
import { DoctorsComponent } from './components/usecases/receptionist-usecases/list-doctors/doctors/doctors.component';
import { CreateWitingListItemAccordionComponent } from './components/usecases/receptionist-usecases/create-waiting-list-item/create-witing-list-item-accordion/create-witing-list-item-accordion.component';
import { CreateEmployeeFormComponent } from './components/usecases/receptionist-usecases/create-employee/create-employee-form/create-employee-form.component';
import { EmployeeComponent } from './components/usecases/receptionist-usecases/show-employee/employee/employee.component';
import { DoctorDashboardComponent } from './components/usecases/doctor-usecases/shared/doctor-dashboard/doctor-dashboard.component';
import { HistoryComponent } from './components/usecases/doctor-usecases/list-visits-history/history/history.component';
import { CreateVisitComponent } from './components/usecases/doctor-usecases/create-visit/create-visit/create-visit.component';
import { DoctorPhonesComponent } from './components/usecases/doctor-usecases/list-doctor-phones/doctor-phones/doctor-phones.component';
import { CreateDoctorPhoneComponent } from './components/usecases/doctor-usecases/create-doctor-phone/create-doctor-phone/create-doctor-phone.component';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuard } from './services/authentication/guards/role-guard';
import { Roles } from './classes/authentication/roles-constants/roles';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },

  {
    path: 'home',
    component: HomeComponent,
    canActivate: [RoleGuard],
    data: { role: Roles.NotRegistered }
  },
  
  {
    path: 'errors/forbidden',
    component: ForbiddenComponent,
    canActivate: [RoleGuard],
    data: { role: Roles.NotRegistered }
  },

  {
    path: 'admin',
    component: AdminDashboardComponent,
    canActivate: [RoleGuard],
    canActivateChild: [RoleGuard],
    
    data: { role: Roles.Admin },
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
      },
      {
        path: 'doctors',
        component: DoctorUsersComponent
      },
      {
        path: 'doctors/create',
        component: CreateDoctorUserFormComponent
      },
      {
        path: 'doctors/update/:id',
        component: UpdateDoctorUserComponent
      },
      {
        path: 'receptionists',
        component: ReceptionistUsersComponent
      }
    ]
  },

  {
    path: 'doctor',
    component: DoctorDashboardComponent,
    canActivate: [RoleGuard],
    canActivateChild: [RoleGuard],
    
    data: { role: Roles.Doctor },
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
      },
      {
        path: 'waitinglist',
        component: WaitingListComponent
      },      
      {
        path: 'history/:id',
        component: HistoryComponent
      },  
      {
        path: 'visits/create/:id',
        component: CreateVisitComponent
      },   
      {
        path: 'phones',
        component: DoctorPhonesComponent
      },
      {
        path: 'phones/create',
        component: CreateDoctorPhoneComponent
      },
    ]
  },  

  {
    path: 'receptionist',
    component: ReceptionistDashboardComponent,
    canActivate: [RoleGuard],
    canActivateChild: [RoleGuard],
    
    data: { role: Roles.Receptionist },
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
      },
      {
        path: 'waitinglist',
        component: WaitingListComponent
      },
      {
        path: 'waitinglist/create',
        component: CreateWitingListItemAccordionComponent
      },
      {
        path: 'employees/create',
        component: CreateEmployeeFormComponent
      },
      {
        path: 'employees/:id',
        component: EmployeeComponent
      },
      {
        path: 'doctors',
        component: DoctorsComponent
      }
    ]
  },
  // Everything else
  {
    path: '**',
    component: NotFoundComponent
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
