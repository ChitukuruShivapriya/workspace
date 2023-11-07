import { TestBed } from '@angular/core/testing';

import { AuthGuard } from './auth.guard'; // Import AuthGuard class
import { HttpClientModule } from '@angular/common/http';
import { RouterTestingModule } from '@angular/router/testing';

describe('AuthGuard', () => { // Use 'AuthGuard' instead of 'authGuard'
  let guard: AuthGuard | any;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, RouterTestingModule],
    });
  });

  fit('Frontend_should_create_AuthGuard', () => {
    guard = TestBed.inject(AuthGuard) as any; // Create an instance of AuthGuard

    expect(guard).toBeTruthy();
  });
});
