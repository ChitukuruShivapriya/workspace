
import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { AuthService } from './auth.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

describe('AuthService', () => {
  let service: AuthService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, HttpClientTestingModule],
      providers: [AuthService],
    });

    service = TestBed.inject(AuthService) as any;
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('Frontend_should_have_logout_function_in_AuthService', () => {
    const service = TestBed.inject(AuthService) as any;
    expect(service.logout).toBeDefined();
  });

  fit('Frontend_should_send_a_POST_request_to_register_a_customer', () => {
    const username = 'testUser';
    const password = 'testPassword';
    const role = 'customer';

    service = TestBed.inject(AuthService) as any;


    (service as any)["register"](username, password, role).subscribe((userResponse: any) => {
      // Check if the response matches the expected data
      expect(userResponse).toBeDefined();
      expect(userResponse.username).toEqual(username);
      expect(userResponse.role).toEqual(role);
    });

    const req = httpTestingController.expectOne(`${service.baseUrl}/auth/register`);
    expect(req.request.method).toEqual('POST');

    req.flush({ username, role });
  });

  fit('Frontend_should_send_a_POST_request_to_login', () => {
    const username = 'testUser';
    const password = 'testPassword';
    const token = 'testToken';
    const response = { token, username };

    (service as any)['login'](username, password).subscribe((loginResponse: any) => {
      // Check if the response matches the expected data
      expect(loginResponse).toBeDefined();
      // expect(loginResponse.token).toEqual(token);
      // expect(loginResponse.token.username).toEqual(username);
    });

    const req = httpTestingController.expectOne(`${service.baseUrl}/Auth/login`);
    expect(req.request.method).toEqual('POST');

    req.flush(response);

    // The test should automatically complete due to the subscription
  });
});
