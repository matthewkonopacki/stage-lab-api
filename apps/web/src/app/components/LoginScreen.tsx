import { signIn } from '@/auth';

export default async function LoginScreen() {
  return (
    <div className="min-h-screen flex">
      <div className="min-h-screen flex-1 bg-[linear-gradient(135deg,#0f172a_0%,#112a4d_100%)]">
        <div className="h-full p-15 flex flex-col justify-between">
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
            <form
              action={async (formData) => {
                'use server';
                await signIn('credentials', formData);
              }}
              className="space-y-5"
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
              <button
                type="submit"
                className="w-full bg-primary hover:bg-blue-700 text-white font-bold h-12 rounded-xl transition-all shadow-lg shadow-primary/20 flex items-center justify-center gap-2"
              >
                Sign In
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}
