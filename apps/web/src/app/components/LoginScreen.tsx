import { signIn } from '@/auth';
import { AuthError } from 'next-auth';
import Link from 'next/link';
import { redirect } from 'next/navigation';

export default async function LoginScreen({ error }: { error?: string }) {
  return (
    <div className="min-h-screen flex">
      <div className="min-h-screen flex-1 bg-[linear-gradient(135deg,#0f172a_0%,#112a4d_100%)]">
        <div className="h-full p-12 flex flex-col justify-between">
          <h1 className="text-5xl text-slate-50 font-black tracking-tight flex-1">
            StageLab
          </h1>
          <div className="max-w-lg">
            <h3 className="text-3xl text-slate-50 font-black tracking-tight flex-1 mb-5">
              Empowering performance through seamless orchestration.
            </h3>
            <h4 className="text-2xl text-slate-50 font-100 tracking-tight flex-1">
              Join the world's leading performing arts organizations in managing
              rehearsals, talent, and social connectivity in one unified
              workspace.
            </h4>
          </div>
          <div className="flex flex-col flex-1 justify-end">
            <h4 className="text-lg text-slate-50 font-100 tracking-tight">
              Trusted by 200+ ensembles
            </h4>
          </div>
        </div>
      </div>
      <div className="min-h-screen flex-1 bg-slate-50">
        <div className="w-full h-full flex items-center justify-center p-8 md:p-16 lg:p-24 flex flex-col">
          <div className="w-full max-w-md">
            <div className="mb-8">
              <h1 className="text-3xl font-black text-slate-900 tracking-tight">
                Sign In
              </h1>
              <p className="text-slate-600 mt-2">
                Welcome back! Please enter your details.
              </p>
            </div>
            {error && (
              <div className="mb-4 p-3 rounded-xl bg-red-50 border border-red-200 text-red-700 text-sm">
                Invalid email or password. Please try again.
              </div>
            )}
            <form
              action={async (formData) => {
                'use server';
                try {
                  await signIn('credentials', {
                    ...Object.fromEntries(formData),
                    redirectTo: '/',
                  });
                } catch (err) {
                  if (err instanceof AuthError) {
                    redirect('/login?error=invalid');
                  }
                  throw err;
                }
              }}
              className="space-y-5 mb-5"
            >
              <div className="flex flex-col">
                <label className="block text-sm font-semibold text-slate-900 mb-2">
                  Email
                </label>
                <input
                  className="w-full h-12 px-4 rounded-xl border border-slate-200 bg-white focus:ring-2 focus:ring-primary/20 focus:border-primary outline-none transition-all placeholder:text-slate-400 text-slate-900"
                  name="email"
                  type="email"
                  placeholder="Email"
                  required
                />
              </div>
              <div className="flex flex-col">
                <label className="block text-sm font-semibold text-slate-900 mb-2">
                  Password
                </label>
                <input
                  className="w-full h-12 px-4 rounded-xl border border-slate-200 bg-white focus:ring-2 focus:ring-primary/20 focus:border-primary outline-none transition-all placeholder:text-slate-400 text-slate-900"
                  name="password"
                  type="password"
                  placeholder="Password"
                  required
                />
              </div>
              <button type="submit" className="primary-btn">
                Sign In
              </button>
            </form>
            <Link className="secondary-btn" href="/sign-up">
              Create New Account
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
}
