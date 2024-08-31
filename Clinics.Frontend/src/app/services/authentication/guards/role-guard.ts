import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanActivateChild, GuardResult, MaybeAsync } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { UserData } from '../../../classes/authentication/user-data';
import { Roles } from '../../../classes/authentication/roles-constants/roles';


@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate, CanActivateChild {

  constructor(private authenticationService: AuthenticationService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const userData: UserData | null = this.authenticationService.getUserData();
    const requiredRole: string = route.data['role'];

    // No required role
    if (!requiredRole)
        return true;

    // No required role
    if (requiredRole === Roles.NotRegistered)
        return true;

    // Reauired role, but not registered user
    if (!userData)
    {
      this.router.navigate(["errors/forbidden"]);
      return false;
    }

    if (userData.role !== requiredRole)
    {
      this.router.navigate(["errors/forbidden"]);
      return false;
    }
    
    return true;
    
  }

  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): MaybeAsync<GuardResult> {
    return this.canActivate(childRoute, state);
  }

}