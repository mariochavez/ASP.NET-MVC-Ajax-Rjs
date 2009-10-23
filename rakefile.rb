COMPILE_TARGET = "Debug"
CLR_VERSION = "v3.5"
SOLUTION = "Source/DecisionesInteligentes.Rjs.sln"
OUTPUT = "Source/DecisionesInteligentes.Rjs.Mvc"

require "BuildLibs/BuildUtils.rb"
require 'rubygems'
require 'fileutils'

include FileUtils

props = { :archive => "Distribution" }
task :default => ["build:all"]
 
namespace :build do
  
  task :all => [:clean, :compile, :harvest]
  
  desc "Prepares the working directory for a new build"
  task :clean do
    #TODO: do any other tasks required to clean/prepare the working directory
    Dir.mkdir props[:archive] unless Dir.exists?(props[:archive])
  end
  
  desc "Use MSBuild to build the solution"
  task :compile => [:clean] do
    MSBuildRunner.compile :compilemode => COMPILE_TARGET, :solutionfile => SOLUTION, :clrversion => CLR_VERSION
    
    
  end
  
  desc "Harvest build outputs to: '#{pwd}\\props[:archive]'"
  task :harvest do
    copy("#{OUTPUT}/bin/#{COMPILE_TARGET}/DecisionesInteligentes.Rjs.Mvc.dll", props[:archive])
    copy("#{OUTPUT}/bin/#{COMPILE_TARGET}/DecisionesInteligentes.Rjs.Mvc.pdb", props[:archive])
    cp_r "#{OUTPUT}/Scripts", props[:archive]
  end
  
end