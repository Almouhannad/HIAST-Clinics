import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/root/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { LayoutComponent } from './components/template/layout/layout.component';
import { HeaderComponent } from './components/template/header/header.component';
import { FooterComponent } from './components/template/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { LoginFormComponent } from './components/Authentication/login-form/login-form.component';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    NgbModule,
    ToastrModule.forRoot(),
  ],

  // creators of services that this module contributes to the
  // global collection of services; they become accessible in
  // all parts of the app
  providers: [],

  // components and directives that belong to this module
  // the subset of declarations that should be visible and usable in
  // the component templates of other modules
  declarations: [
    AppComponent,
    LayoutComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    LoginFormComponent
  ],
  
  // identifies the root component that Angular should
  // bootstrap when it starts the application
  bootstrap: [AppComponent]
})
export class AppModule { }
