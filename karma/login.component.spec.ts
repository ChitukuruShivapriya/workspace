import { ComponentFixture, TestBed, async, fakeAsync, tick } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';

import { LoginComponent } from './login.component';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthService } from '../services/auth.service';
import { of } from 'rxjs';
import { Router } from '@angular/router'; // Import Router
import { DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let authService: AuthService;
  let debugElement: DebugElement;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, HttpClientModule, RouterTestingModule],
      declarations: [LoginComponent],
      providers: [AuthService]
    }).compileComponents();
  }));


  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent) as any;
    component = fixture.componentInstance as any;
    authService = TestBed.inject(AuthService) as any;
    fixture.detectChanges();
    debugElement = fixture.debugElement;

  });

  fit('Frontend_LoginComponent', () => {
    expect(component).toBeTruthy();
  });

  fit('Frontend_call_login_method_on_admin_login_LoginComponent', () => {
    authService = TestBed.inject(AuthService) as any;
    fixture = TestBed.createComponent(LoginComponent) as any;
    component = fixture.componentInstance as any;


    spyOn(authService as any, 'login').and.returnValue(of({ role: 'ADMIN' }));
    const router = TestBed.inject(Router); // Inject Router
    spyOn(router, 'navigate'); // Spy on router's navigate method

    component.username = 'admin';
    component.password = 'password';
    // component.login();
    (component as any)['login']();

    expect((authService as any)['login']).toHaveBeenCalledWith('admin', 'password');
  });

  // fit('Week5_Day4_should_navigate_to_admin_on_admin_login', () => {
  //   spyOn(authService, 'login').and.returnValue(of({ role: 'admin' }));
  //   const router = TestBed.inject(Router); // Inject Router
  //   spyOn(router, 'navigate'); // Spy on router's navigate method

  //   component.username = 'admin';
  //   component.password = 'Test@123';
  //   component.login();

  //   expect(router.navigate).toHaveBeenCalledWith(['/admin']); // Use router's navigate method
  // });


  fit('Frontend_should_call_login_method_on_customer_login_LoginComponent', () => {
    spyOn(authService as any, 'login').and.returnValue(of({ role: 'customer' }));
    const router = TestBed.inject(Router); // Inject Router
    spyOn(router as any, 'navigate'); // Spy on router's navigate method

    component.username = 'organizer';
    component.password = 'password';
    (component as any)['login']();

    expect((authService as any)['login']).toHaveBeenCalledWith('organizer', 'password');
  });

  fit('Frontend_should_have_empty_username_and_password_initially_LoginComponent', () => {
    expect((component as any).username).toBe('');
    expect((component as any).password).toBe('');
  });

  fit('Frontend_should_call_login_method_on_form_submission_LoginComponent', () => {
    spyOn(component, 'login');

    const button = fixture.nativeElement.querySelector('button');
    (component as any).username = 'testUser';
    (component as any).password = 'testPassword';
    fixture.detectChanges();

    button.click();

    expect((component as any)['login']).toHaveBeenCalled();
  });


  fit('Frontend_should_show_username_required_error_message_LoginComponent', fakeAsync(() => {
    const usernameInput = debugElement.query(By.css('#username'));
    usernameInput.nativeElement.value = ''; // Set an empty value
    usernameInput.nativeElement.dispatchEvent(new Event('input')); // Trigger input event
    fixture.detectChanges();

    tick(); // Advance time to handle async operations

    const errorMessage = debugElement.query(By.css('.error-message'));
    // console.log(errorMessage);

    expect(errorMessage.nativeElement.textContent).toContain('Username is required');
  }));

  fit('Frontend_should_show_password_required_error_message_LoginComponent', () => {
    const passwordInput = debugElement.query(By.css('#password'));
    passwordInput.nativeElement.value = ''; // Set an empty value
    passwordInput.nativeElement.dispatchEvent(new Event('input')); // Trigger input event
    fixture.detectChanges();

    const errorMessage = debugElement.query(By.css('.error-message'));
    expect(errorMessage.nativeElement.textContent).toContain('Password is required');
  });

  // fit('should disable submit button if form is invalid', () => {
  //   const submitButton = debugElement.query(By.css('button[type="submit"]'));

  //   // Set initial form control values
  //   const usernameInput = debugElement.query(By.css('#username'));
  //   const passwordInput = debugElement.query(By.css('#password'));

  //   usernameInput.nativeElement.value = ''; // Invalid username
  //   passwordInput.nativeElement.value = ''; // Invalid password

  //   usernameInput.nativeElement.dispatchEvent(new Event('input'));
  //   passwordInput.nativeElement.dispatchEvent(new Event('input'));

  //   fixture.detectChanges(); // Trigger change detection

  //   expect(submitButton.nativeElement.disabled).toBe(true);  // Expect button to be disabled
  // });






  // Add more test cases for different scenarios, e.g., invalid login, etc.
});
