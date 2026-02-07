import { signIn } from '@/auth';
import { AuthError } from 'next-auth';
import { redirect } from 'next/navigation';

export default function SignUpForm() {
  return (
    <div className="w-full max-w-md">
      <div className="mb-8">
        <h1 className="text-3xl font-black text-slate-900 tracking-tight">
          Create Your Account
        </h1>
        <p className="text-slate-600 mt-2">
          Join thousands of organizations managing their craft on StageLab.
        </p>
      </div>
      <form
        action={async (formData) => {
          'use server';
          try {
            await signIn('credentials', { ...Object.fromEntries(formData), redirectTo: '/' });
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
            First Name
          </label>
          <input
            className="w-full h-12 px-4 rounded-xl border border-slate-200 bg-white focus:ring-2 focus:ring-primary/20 focus:border-primary outline-none transition-all placeholder:text-slate-400 text-slate-900"
            name="firstName"
            placeholder="First Name"
            required
          />
        </div>
        <div className="flex flex-col">
          <label className="block text-sm font-semibold text-slate-900 mb-2">
            Last Name
          </label>
          <input
            className="w-full h-12 px-4 rounded-xl border border-slate-200 bg-white focus:ring-2 focus:ring-primary/20 focus:border-primary outline-none transition-all placeholder:text-slate-400 text-slate-900"
            name="lastName"
            placeholder="Last Name"
            required
          />
        </div>
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
          <label className="block text-sm font-semibold text-slate-900">
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
        <button
          type="submit"
          className="primary-btn"
        >
          Create Account
        </button>
      </form>
    </div>
  )
}