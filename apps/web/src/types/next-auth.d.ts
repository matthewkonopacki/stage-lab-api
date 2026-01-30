import 'next-auth';

declare module 'next-auth' {
  interface User {
    id: string;
    email: string;
    token: string;
    firstName: string;
    lastName: string;
    role: string;
  }

  interface Session {
    user: {
      id: string;
      email: string;
      name?: string | null;
      firstName: string;
      lastName: string;
      role: string;
    };
    accessToken: string;
  }
}

declare module 'next-auth/jwt' {
  interface JWT {
    id: string;
    accessToken: string;
    firstName: string;
    lastName: string;
    role: string;
  }
}